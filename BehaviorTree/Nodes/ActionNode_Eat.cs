namespace BehaviorTree{
    /// <summary>
    /// 行为节点：吃饭
    /// </summary>
    public class ActionNode_Eat : NodeAction {

        private Student student;

        public override ResultType Execute()
        {
            if(student == null)
                student = ObjManager.GetObj(RoleId) as Student;
            // 吃饱了
            if (student.IsFull())
            {
                return ResultType.Success;
            }

            // 吃饭增加能量，减少饭
            student.AddEnergy(0.5f);
            student.ChangeFood(-0.4f);
            return ResultType.Running;
        }
    }
}