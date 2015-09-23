package assign1;

import junit.framework.TestCase;
import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.CoreMatchers.*;

public class PerfectNumberFinderImperativeTest extends TestCase{
    public void testIsPerfectNumberWhenTrue() {
        int num = 28;
        boolean expected = true;
        assertEquals(expected, PerfectNumberFinderImperative.isPerfectNum(num));
    }

    public void testIsPerfectNumberWhenFalse() {
        int num = 10;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderImperative.isPerfectNum(num));
    }

    public void testPerfectNumIsIsOdd() {
        int num = 7;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderImperative.isPerfectNum(num));
    }

    public void testFactorizeCorrect() {
        int num = 6;
        assertEquals(num, PerfectNumberFinderImperative.sumOfFactors(num));
    }

    public void testFactorizeFail() {
        int num = 30;
        assertThat(num, not(equalTo(PerfectNumberFinderImperative.sumOfFactors(num))));
    }

    public void testIsPerfectNumberFailWhenNegative() {
        int num = -28;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderImperative.isPerfectNum(num));
    }

    public void testIsPerfectNumberFailWhenZero() {
        int num = 0;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderImperative.isPerfectNum(num));
    }

    public void testIsPerfectNumberFailWhenOne() {
        int num = 1;
        boolean expected = false;
        assertEquals(expected, PerfectNumberFinderImperative.isPerfectNum(num));
    }
}