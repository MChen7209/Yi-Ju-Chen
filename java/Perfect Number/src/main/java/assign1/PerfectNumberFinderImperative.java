package assign1;

public final class PerfectNumberFinderImperative
{
	public static boolean isPerfectNum(int num) {
		return num > 1 && sumOfFactors(num) == num;
	}
	
	public static int sumOfFactors(int num) {
		int sum = 0;
		for(int i = 1; i < num; i++) {
			if(num % i == 0)
		    		sum += i;
		}
		return sum;
	}
}
