package assign1;

import junit.framework.TestCase;
import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.CoreMatchers.*;
import java.util.List;
import java.util.ArrayList;

public class PerfectNumberFinderFunctionalTest extends TestCase{
    public void testIsPerfectNumberWhenTrue() {
        int num = 28;
        boolean expected = true;
        assertEquals(expected, PerfectNumberFinderFunctional.isPerfectNum(num));
    }

    public void testIsPerfectNumberWhenFalse() {
        int num = 10;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderFunctional.isPerfectNum(num));
    }

    public void testPerfectNumberWhenOdd() {
        int num = 7;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderFunctional.isPerfectNum(num));
    }

    public void testSumOfFactorsCorrect() {
        int num = 6;
        assertEquals(num, PerfectNumberFinderFunctional.sumOfFactors(num));
    }

    public void testSumOfFactorsFail() {
        int num = 30;
        assertThat(num, not(equalTo(PerfectNumberFinderFunctional.sumOfFactors(num))));
    }

    public void testPerfectNumberFailWhenNegative() {
        int num = -28;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderFunctional.isPerfectNum(num));
    }

    public void testPerfectNumberFailWhenZero() {
        int num = 0;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderFunctional.isPerfectNum(num));
    }

    public void testPerfectNumberFailWhenOne() {
        int num = 1;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderFunctional.isPerfectNum(num));
    }
}