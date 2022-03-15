namespace L3
{
    public class FirstQuestion
    {
        public bool Task(int[] x)
        {
            bool flag = true;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}