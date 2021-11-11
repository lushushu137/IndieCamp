using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public int speed = 1;

	private int State;//角色状态
	private int oldState = 0;//前一次角色的状态
	private const int UP = 0;//角色状态向前 
	private const int RIGHT = 1;//角色状态向右
	private const int DOWN = 2;//角色状态向后
	private const int LEFT = 3;//角色状态向左	// Start is called before the first frame update
	
    void Start()
	{
	}

    // Update is called once per frame
    void Update()
    {
        //检测键盘输入，ADSW，控制前后左右
		if (Input.GetKey("w"))
		{
			setState(UP);
		}
		else if (Input.GetKey("s"))
		{
			setState(DOWN);
		}

		if (Input.GetKey("a"))
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
			case 0://角色状态向前时，角色不断向前缓慢移动
				transformValue = Vector3.forward * Time.deltaTime * speed;
				break;
			case 1://角色状态向右时。角色不断向右缓慢移动
				transformValue = Vector3.right * Time.deltaTime * speed;
				break;
			case 2://角色状态向后时。角色不断向后缓慢移动
				transformValue = Vector3.back * Time.deltaTime * speed;
				break;
			case 3://角色状态向左时，角色不断向左缓慢移动
				transformValue = Vector3.left * Time.deltaTime * speed;
				break;
		}
		transform.Rotate(Vector3.up, rotateValue);//旋转角色
		transform.Translate(transformValue, Space.World);//平移角色
		oldState = State;//赋值，方便下一次计算
		State = currState;//赋值，方便下一次计算
	}


}
