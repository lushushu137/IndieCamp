using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Move : MonoBehaviour
{
	public int speed = 1;
    public GameObject AimPrefab;

	public GameObject spiderMesh;
    public Transform spiderMuzzle;

	private int State = 3;//角色状态
	private int oldState = 3;//前一次角色的状态
	private const int RIGHT = 3;
	private const int FRONT = 2;
	private const int LEFT = 1;//角色状态向左	
	private GameObject wall;
	private GameObject Aim = null;
	// Start is called before the first frame update
    void Start()
	{
		wall = GameObject.Find("wall");
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(0))
		{
			setState(FRONT);
			if (Aim == null) {
				Aim = Instantiate(AimPrefab);
			}
			ShowAim();
		}
		else if (Input.GetMouseButtonUp(0)) {
			Destroy(Aim);
			LaunchMesh();
		}
		else if (Input.GetKey("a"))
		{
			setState(LEFT);
		}
		else if (Input.GetKey("d"))
		{
			setState(RIGHT);
		}
		
		
    }
    void setState(int currState)
	{
		Vector3 transformValue = new Vector3();//定义平移向量
		int rotateValue = (currState - State) * 90;
		switch (currState)
		{
			case 1:
				transformValue = Vector3.left * Time.deltaTime * speed;
				break;
			case 2:
				break;
			case 3:
				transformValue = Vector3.right * Time.deltaTime * speed;
			break;

		}
		transform.Rotate(Vector3.up, rotateValue);//旋转角色
		transform.Translate(transformValue, Space.World);//平移角色
		oldState = State;//赋值，方便下一次计算
		State = currState;//赋值，方便下一次计算
	}
	void ShowAim (){
            Vector3 pos= Camera.main.WorldToScreenPoint(wall.transform.position);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z - 0.001f);
			Aim.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
			spiderMuzzle.transform.LookAt(Aim.transform);

	}
	void LaunchMesh(){
            GameObject newMesh = Instantiate(spiderMesh, spiderMuzzle.position, spiderMuzzle.rotation);
			newMesh.transform.LookAt(Aim.transform);

	}
	

}
