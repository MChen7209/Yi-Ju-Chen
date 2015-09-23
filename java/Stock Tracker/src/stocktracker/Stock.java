package stocktracker;

import java.io.File;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;

public class Stock
{
    private String ticker;
    private int numberShares;
    private int currentShareValue;
    private int totalStockValue;
    private File stockReport;
    
    public Stock()
    {
        ticker="";
        numberShares=0;
        currentShareValue=0;
        totalStockValue=0;
        stockReport=null;
    }
    
    public void calculateTotalStockValue()
    {
        totalStockValue = numberShares * currentShareValue;
    }
    

    public void setNumberShares(int shares)
    {
        numberShares = shares;
    }
    
    public int getNumberShares()
    {
        return numberShares;
    }
    
    public void setCurrentShareValue(int value)
    {
        currentShareValue = value;
    }
    
    public int getCurrentShareValue()
    {
        return currentShareValue;
    }
    
    public int getTotalStockValue()
    {
        return totalStockValue;
    }
    

    public static void main(String args[])
    {
            //Here temporarly to make gradle work.
    }
}
