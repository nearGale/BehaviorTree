using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Student test = new Student();
            bool running = true;
            while(running){
                test.Update();
            }
            Console.WriteLine("Hello World!");
        }
    }
}

public class Student {
    
    private AiComponent ai = new AiComponent(); // 根节点

    private float energy = 0;      // 能量值
    private float minEnergy = 50;  // 能量下限：当能量 <= 能量下限      感到饥饿
    private float maxEnergy = 100; // 能量上限：当能量 >= 能量上线时    表示吃饱了

    private float food = 0;        // 食物量：
    private float minFood = 0;     // 食物下限：当食物量 <= 食物下限时  没有食物了
    private float maxFood = 100;   // 食物上限：当食物量 >= 食物上限时  表示饭做好了

    // Use this for initialization
    public Student () {
        Init();
        ai.Init(0, StudentAi.nodesGeneratorDict);
    }

    // Update is called once per frame
    public void Update() {
        ChangeEnergy(-0.2f); // 每帧执行消耗能量
        // Console.WriteLine("能量 -0.2");
        ai.Update();
    }

    /// <summary>
    /// 初始化添加行为树节点
    /// </summary>
    private void Init()
    {
        ObjManager.RegObj(this);
    }

    #region 饿了吃饭
    public bool IsHungry()
    {
        Console.WriteLine("饿了么" + (energy <= minEnergy));
        return energy <= minEnergy;
    }

    public void AddEnergy(float value)
    {
        ChangeEnergy(value);
        Console.WriteLine("Eat");
    }

    private void ChangeEnergy(float value)
    {
        energy += value;
    }

    public bool IsFull()
    {
        return energy >= maxEnergy;
    }
    #endregion

    #region 食物
    public bool HasFood()
    {
        return food > minFood;
    }

    public bool FoodEnough()
    {
        return food >= maxFood;
    }

    public void Cooking(float value)
    {
        ChangeFood(value);
        Console.WriteLine("Cooking");
    }

    public void ChangeFood(float value)
    {
        food += value;
    }
    #endregion
}










