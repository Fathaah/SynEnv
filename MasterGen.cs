using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objective randomly generate the scenary as well as the Object in hand. havve different views orientations, etc.

public class MasterGen : MonoBehaviour
{   
    Camera camera;
    GameObject[] obj;
     //Objects in scenary
    public GameObject[] obj_intrest; //Objects not on scenary
    int len_objs;
    public int no_env_obj = 20;
    GameObject temp;
    GameObject[] gameObjects;
    GameObject[] lights;
    public Material Mat1;
    float distance;
    float frustumHeight;
    float frustumWidth;
    int idx_obj;
    Light Main_Light;
    public float rot_x_max, rot_y_max, rot_z_max;
    public float rot_x_min, rot_y_min, rot_z_min;


    void Start()
    {   camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        obj = Resources.LoadAll<GameObject>("Models");
        obj_intrest = Resources.LoadAll<GameObject>("Target_models");
        lights = Resources.LoadAll<GameObject>("Lights");
        Main_Light = GameObject.FindWithTag("Main_Light").GetComponent<Light>();
        len_objs = (obj.Length);
    }

    void Update(){
        
        // if (Input.GetButton("Fire1"))
        // {
        //     DestroyAll();
        // }
        if (Input.GetButton("Fire2"))
        {     DestroyAll();
              Generate_Background();  
        }
        // while(true){
        //     DestroyAll();
        //     Generate_Background();
        //     StartCoroutine( Order() );
        // }
    }

    void Generate_Background()
    {   
        for(int i = 0;i < no_env_obj;i++)
        {
            idx_obj = Random.Range(0, len_objs);
            distance = Random.Range(3f , 15.0f);
            frustumHeight = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            frustumWidth = frustumHeight * camera.aspect;
            Vector3 obj_loc = new Vector3(Random.Range(camera.transform.position.x - frustumWidth / 2 + 1f, camera.transform.position.x + frustumWidth / 2 - 1f),
                Random.Range(camera.transform.position.y - frustumHeight / 2 + 1f, camera.transform.position.y + frustumHeight / 2 - 1f),
                1.5f + camera.transform.position.z + distance);
            place_obj(obj[idx_obj],obj_loc);
            
            
        }

        spawn_target_object();
        enLighten();
        
    }

    void place_obj(GameObject new_obj, Vector3 loc){
        temp = Instantiate(new_obj, loc, Random.rotation);   
        float scale_fact =  Random.Range(0.2f,5f);
        temp.transform.localScale = new Vector3(scale_fact,scale_fact,scale_fact);
        MeshRenderer mesh = temp.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        temp.isStatic = true;
        temp.tag = "Scene_object";
        // Material[] mat1;
        // mat1 = temp.transform.GetChild(0).gameObject.GetComponentsInChildren<Material>();
        // mat1[0].SetColor("_Color", Color.red);

    }

    void spawn_target_object(){

        distance = Random.Range(1.5f , 2.8f);
        frustumHeight = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        frustumWidth = frustumHeight * camera.aspect;
        Quaternion target = Quaternion.Euler(Random.Range(rot_x_min , rot_x_max), Random.Range(rot_y_min , rot_y_max), Random.Range(rot_z_min , rot_z_max));
        Vector3 obj_loc = new Vector3(Random.Range(camera.transform.position.x - frustumWidth / 2 + 0.5f, camera.transform.position.x + frustumWidth / 2 - .5f),
                Random.Range(camera.transform.position.y - frustumHeight / 2 + 0.5f , camera.transform.position.y + frustumHeight / 2 - 0.5f ),
                camera.transform.position.z + distance);
        GameObject main_obj = Instantiate(obj_intrest[Random.Range(0,obj_intrest.Length)], obj_loc, target);
        main_obj.transform.localScale = new Vector3(2,2,2);
        main_obj.tag = "Scene_object";

    }

    void enLighten(){
        RenderSettings.skybox = Mat1;
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", Random.Range(0f, 2.5f));
        RenderSettings.skybox.SetFloat("_Exposure",Random.Range(0f, 2.5f));
        int no_lights = Random.Range(2,10);
        for(int k = 0;k < no_lights;k++){

            idx_obj = Random.Range(0, lights.Length);
            distance = Random.Range(3f , 15.0f);
            frustumHeight = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            frustumWidth = frustumHeight * camera.aspect;
            Vector3 obj_loc = new Vector3(Random.Range(camera.transform.position.x - frustumWidth / 2 + 1f, camera.transform.position.x + frustumWidth / 2 - 1f),
                Random.Range(camera.transform.position.y - frustumHeight / 2 + 1f, camera.transform.position.y + frustumHeight / 2 - 1f),
                1.5f + camera.transform.position.z + distance);
            temp = Instantiate(lights[idx_obj], obj_loc, Random.rotation);
            temp.tag = "Scene_object";
            temp.GetComponent<Light>().color = new Color((float)Random.Range(0f, 1f), 
                                                        (float)Random.Range(0f, 1f), 
                                                        (float)Random.Range(0f, 1f),
                                                        1);
        }
        Main_Light.color =  new Color((float)Random.Range(0f, 1f), 
                                                        (float)Random.Range(0f, 1f), 
                                                        (float)Random.Range(0f, 1f),
                                                        1);

        Main_Light.intensity = Random.Range(1.5f,2.5f);

    }

    void DestroyAll()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Scene_object");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
