#! bin/env python3
import socket
import threading
from queue import Queue
import os, sys, time


def Send(group, send_queue, server_socket):
    print('Thread Send Start')
    while True:
        try:
            recv = send_queue.get()
            if recv == 'Group Changed':
                print('Group Changed')
                break

            if len(str(recv[0])) == 0:
                continue

            for conn in group:
                msg = str(recv[0])
                if recv[1] != conn:
                    conn.send(bytes(msg.encode()))

            if str(recv[0]) == 'END GAME':
                print('restart')
                time.sleep(3)
                os.execl(sys.executable, sys.executable, *sys.argv)

        except:
            pass


def Recv(conn, count, send_queue):
    print('Thread Recv' + str(count) + ' Start')
    while True:
        try:
            data = conn.recv(1024).decode()
            send_queue.put([data, conn, count])
        except ConnectionResetError:
            print('Connection rest by peer - Please Replay Unity!')
            print('Restarting Server...')
            time.sleep(3)
            os.execl(sys.executable, sys.executable, *sys.argv)


# TCP Echo Server
if __name__ == '__main__':
    send_queue = Queue()
    HOST = '' # 수신 받을 모든 IP를 의미
    PORT = int(sys.argv[1]) # 수신받을 Port
    server_sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # TCP Socket
    server_sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_sock.bind((HOST, PORT)) # 소켓에 수신받을 IP주소와 PORT를 설정
    server_sock.listen(10) # 소켓 연결, 여기서 파라미터는 접속수를 의미
    count = 0
    group = [] #연결된 클라이언트의 소켓정보를 리스트로 묶기 위함

    while True:
        count = count + 1
        conn, addr = server_sock.accept() # 해당 소켓을 열고 대기
        group.append(conn) #연결된 클라이언트의 소켓정보
        print('Connected ' + str(addr)) #소켓에 연결된 모든 클라이언트에게 동일한 메시지를 보내기 위한 쓰레드(브로드캐스트) #연결된 클라이언트가 1명 이상일 경우 변경된 group 리스트로 반영

        if count > 2:
            print('User ID passed 2 : Restarting... (Replay Unity Too!)')
            time.sleep(3)
            os.execl(sys.executable, sys.executable, *sys.argv)
        elif count > 1:
            send_queue.put('Group Changed')
            thread1 = threading.Thread(target=Send, args=(group, send_queue, server_sock,))
            thread1.start()
            pass
        else:
            thread1 = threading.Thread(target=Send, args=(group, send_queue, server_sock,))
            thread1.start() #소켓에 연결된 각각의 클라이언트의 메시지를 받을 쓰레드

        thread2 = threading.Thread(target=Recv, args=(conn, count, send_queue,))
        thread2.start()

