package assign1;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.*;
import java.util.function.IntPredicate;

public final class PerfectNumberFinderFunctional
{
	public static boolean isPerfectNum(int num) {
		return num > 1 && sumOfFactors(num) == num;
	}
	
	public static int sumOfFactors(int num) {
    		return IntStream.range(1, num)
                    		.filter(index -> num % index == 0)
                    		.sum();
	}
}
