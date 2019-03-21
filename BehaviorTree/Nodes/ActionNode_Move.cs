namespace BehaviorTree{
    /// <summary>
    /// 行为节点：走向目标
    /// </summary>
    public class ActionNode_Move : NodeAction {
        private Student student;
        // 朝目标移动
        private string targetName = string.Empty;

        private float speed = 5;

        public override ResultType Execute()
        {
            return ResultType.Success;
        }

        public void SetTarget(string name)
        {
            targetName = name;
        }

        public void SetStudent(Student student)
        {
            this.student = student;
        }
    }
}