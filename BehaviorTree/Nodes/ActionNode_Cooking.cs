namespace BehaviorTree{
    /// <summary>
    /// 行为节点：做饭
    /// </summary>
    public class ActionNode_Cooking : NodeAction {
        private Student student;

        public override ResultType Execute()
        {
            if(student == null)
                student = ObjManager.GetObj(RoleId) as Student;
            // 食物足够了
            if (student.FoodEnough()) 
            {
                return ResultType.Success;
            }

            student.Cooking(0.5f);
            return ResultType.Running;
        }
    }           
}