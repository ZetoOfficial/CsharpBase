namespace L3
{
    public class SecondQuestion
    {
        public int Task(int[] arr)
        {
            int cnt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0 && i % 2 == 0)
                    cnt += arr[i];
            }
            return cnt;
        }
    }
}