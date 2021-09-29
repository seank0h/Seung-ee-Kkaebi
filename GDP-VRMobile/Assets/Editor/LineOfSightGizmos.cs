using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SearchLight))]
public class LineOfSightGizmos : Editor
{
    private void OnSceneGUI()
    {
        SearchLight los = (SearchLight)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(los.transform.position, Vector3.up, Vector3.forward, 360, los.radius);

        Vector3 viewAngle01 = DirectionFromAngle(los.transform.eulerAngles.y, -los.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(los.transform.eulerAngles.y, los.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(los.transform.position, los.transform.position + viewAngle01 * los.radius);
        Handles.DrawLine(los.transform.position, los.transform.position + viewAngle02 * los.radius);

        
        if(los.canSeeGhost)
        {
            Handles.color = Color.green;
            Handles.DrawLine(los.transform.position, los.ghostEntities[0].transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
