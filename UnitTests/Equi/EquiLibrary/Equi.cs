namespace EquiNamespace;

public class Equi
{
  public static int Solution(int[] A)
        {
            if (A == null || A.Length == 0)
                return -1;

            long totalSum = A.Sum();
            long leftSum = 0;

            for (int i = 0; i < A.Length; i++)
            {
                totalSum -= A[i];

                if (leftSum == totalSum)
                    return i;

                leftSum += A[i];
            }

            return -1;
        }
}
