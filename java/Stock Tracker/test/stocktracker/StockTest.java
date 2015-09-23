package stocktracker;

import junit.framework.TestCase;
import static org.junit.Assert.*;
import java.io.File;

public class StockTest extends TestCase
{
    private Stock stock;
    
    protected void setUp()
    {
        stock = new Stock();
    }
    
    public void testCalculateTotalStockValue()
    {
        stock.setNumberShares(100);
        stock.setCurrentShareValue(250);
        int expected = 25000;
        stock.calculateTotalStockValue();
        assertEquals(expected,stock.getTotalStockValue());
    }
    
    public void testCalculateTotalStockValueFail()
    {
        stock.setNumberShares(100);
        stock.setCurrentShareValue(350);
        int notExpected = 10000;
        stock.calculateTotalStockValue();
        assertNotEquals(notExpected, stock.getTotalStockValue());
    }
}
