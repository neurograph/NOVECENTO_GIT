 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using System.Xml; 
 using System.Xml.Serialization;
 using System.IO; 
 using System.Text; 
 
public class LIST : MonoBehaviour {
     
     
     public GameObject CubeContainer;
     

     
     public class CubeInfo
     {
         public string prefabName;
         public Vector3 position;
         //public Quaternion rotation;
         
         public CubeInfo()
         {
         }
         
         public CubeInfo(Transform cube ) 
         {
             prefabName = cube.name.Replace("(Clone)", string.Empty);
             position = cube.position;
             //rotation = cube.rotation;
         }
     }
     
     
     public class BuildingInfo
     { // Stores info about all the cubes.
         
         // Make a List holding objects of type CubeInfo
         public List<CubeInfo> cubeList;
         
         public BuildingInfo() 
         {
             // Make a new instance of the List "cubeList"
         }
         
         public BuildingInfo(GameObject rootObject) 
         {
             cubeList = new List<CubeInfo>();
             
             foreach (Transform child in rootObject.transform) 
             {
                 cubeList.Add (new CubeInfo(child));
                 //print (child);
             }
         }
         
         public void reload(GameObject rootObject)
         {
             // Rebuild the cubes after loading building info:
             foreach (var cubeInfo in cubeList) 
             {
                 GameObject cube = Instantiate(Resources.Load(cubeInfo.prefabName),cubeInfo.position, Quaternion.identity) as GameObject;
                 cube.transform.parent = rootObject.transform;
             }
         }
     }
     
     
     void Save(GameObject rootObject, string filename) 
     {
         BuildingInfo buildingInfo = new BuildingInfo(rootObject);
         XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
         TextWriter writer = new StreamWriter(filename);
         serializer.Serialize(writer, buildingInfo);
         writer.Close();
         print ("Objects saved into XML file\n");
     }
     
     void Load(GameObject rootObject, string filename) 
     {
         //        while(rootObject.transform.GetChildCount()>0)
         //        {
         //            GameObject.Destroy(rootObject.transform.GetChild (0));
         //        } 
         
         XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
         TextReader reader = new StreamReader(filename);
         BuildingInfo buildingInfo = serializer.Deserialize(reader) as BuildingInfo;
         buildingInfo.reload(rootObject);
         reader.Close();
         print ("Objects loaded from XML file\n");
     }
     
     void OnGUI()
     {
         if (GUI.Button (new Rect (30, 60, 150, 30), "Save State")) 
         {
             Save (CubeContainer, "savefile.xml");
         }
         
         if (GUI.Button (new Rect (30, 90, 150, 30), "Load State")) 
         {
             Load (CubeContainer, "savefile.xml");
         }
     }
 }
