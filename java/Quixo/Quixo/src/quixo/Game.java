package quixo;

public class Game
{
    private FaceType[][] gameBoard;
    private FaceType currentPlayer;
    private String gameNote;
    private FaceType firstPlayer;
    
    public enum Direction 
    {
        LEFT, RIGHT, UP, DOWN
    }
    
    public enum FaceType
    {
        X, O, BLANK
    }
    
    public Game()
    {
        gameBoard = new FaceType[5][5];
        for (int i=0; i<5; i++)
        {
            for(int j=0; j<5; j++)
            {
                gameBoard[i][j]= FaceType.BLANK; 
            }
        }
        gameNote = "NONE";
    }
    
    public void setFace(int x, int y, FaceType symbol)
    {
        gameBoard[x][y] = symbol;
    }
    
    public void moveCube(int x, int y, Direction dir)
    {
        boolean validMove = true;
        if((x==0 || x==4 || y==0 || y==4) && (gameBoard[x][y]==currentPlayer || gameBoard[x][y]==FaceType.BLANK))
	{	
	    switch(dir)
            {
                case LEFT:
                    if(x>0)
                    {
                        for(int current=x; current>0; current--)
                            gameBoard[current][y] = gameBoard[current-1][y];
                        gameBoard[0][y] = currentPlayer;
                    }
                    else
                        validMove = false;
                    break;
            	case RIGHT:
                    if(x<4)
                    {
                        for(int current=x; current<4; current++)          
                            gameBoard[current][y] = gameBoard[current+1][y];
                        gameBoard[4][y] = currentPlayer;
                    }
                    else
                        validMove = false;
                    break;
            	case UP:
                    if(y>0)
                    {
                        for(int current=y; current>0; current--)
                            gameBoard[x][current] = gameBoard[x][current-1];
                        gameBoard[x][0] = currentPlayer;
                    }
                    else
                        validMove = false;
                    break;
            	case DOWN:
                    if(y<4)
                    {
                        for(int current=y; current<4; current++)
                            gameBoard[x][current] = gameBoard[x][current+1];
                        gameBoard[x][4] = currentPlayer;
                    }
                    else
                        validMove = false;
                    break;
            }
            if(validMove == true)
            {
                gameNote="PLAYER "+currentPlayer.toString()+" moves cube { "+x+" , "+y+" } "+dir.toString();
                if(currentPlayer==FaceType.X)
                    currentPlayer=FaceType.O;
                else
                    currentPlayer=FaceType.X;
            }   
            else
                gameNote=gameNote = "INVALID MOVE! PLEASE TRY AGAIN.";
	}
        else
            gameNote = "INVALID MOVE! PLEASE TRY AGAIN.";
    }

    public FaceType checkVictory()
    {
	int x=0;
	int y=0;
	int countX = 0;
        int countO = 0;
	FaceType winner = FaceType.BLANK;

	for(x=0; x<5; x++)
        {
            countX=0;
            countO=0;
            for(y=0; y<5; y++)
            {
                if(gameBoard[x][y] == FaceType.X)
                    countX++;
                if(gameBoard[x][y] == FaceType.O)
                    countO++;
            }

            if(countO == 0 && countX == 5)
            {
                if(winner == FaceType.BLANK)
                    winner = FaceType.X;
                else
                    winner = currentPlayer;
            }

            if(countX == 0 && countO == 5)
            {
		if(winner == FaceType.BLANK)
                    winner = FaceType.O;
		else
                    winner = currentPlayer;
            }    
        }

	for(y=0; y<5; y++)
        {
            countX=0;
            countO=0;
           
            for(x=0; x<5; x++)
            {
                if(gameBoard[x][y] == FaceType.X)
                    countX++;
                if(gameBoard[x][y] == FaceType.O)
                    countO++;
            }
        
            if(countO == 0 && countX == 5)
            {
		if(winner == FaceType.BLANK)
                    winner = FaceType.X;
		else
                    winner = currentPlayer;
            }

            if(countX == 0 && countO == 5)
            {
		if(winner == FaceType.BLANK)
                    winner = FaceType.O;
		else
                    winner = currentPlayer;
            } 
        }

	x=0;
	countX=0;
	countO=0;
	for(y=0; y<5; y++)
	{
	    if(gameBoard[x][y] == FaceType.X)
	        countX++;
	    if(gameBoard[x][y] == FaceType.O)
	        countO++;
	    x++;
	}
        
        if(countO == 0 && countX == 5)
	{
            if(winner == FaceType.BLANK)
                winner = FaceType.X;
            else
		winner = currentPlayer;
	}

        if(countX == 0 && countO == 5)
        {
            if(winner == FaceType.BLANK)
               	winner = FaceType.O;
            else
		winner = currentPlayer;
	} 

	x=0;
	countX=0;
	countO=0;
	for(y=4; y>=0; y--)
	{
	    if(gameBoard[x][y] == FaceType.X)
	        countX++;
	    if(gameBoard[x][y] == FaceType.O)
	        countO++;
	    x++;
	}
        
        if(countO == 0 && countX == 5)
	{
            if(winner == FaceType.BLANK)
               	winner = FaceType.X;
            else
		winner = currentPlayer;
	}

        if(countX == 0 && countO == 5)
        {
            if(winner == FaceType.BLANK)
               	winner = FaceType.O;
            else
		winner = currentPlayer;
	} 

	return winner;
    }
    
    public FaceType getFaceType(int x, int y)
    {
        return gameBoard[x][y];
    }

    public void setCurrentPlayer(FaceType symbol)
    {
	currentPlayer=symbol;
    }

    public FaceType getCurrentPlayer()
    {
	return currentPlayer;
    }
    
    public String getGameNote()
    {
        return gameNote;
    }
    
    public void setFirstPlayer(FaceType symbol)
    {
        firstPlayer = symbol;
    }
    
    public FaceType getFirstPlayer()
    {
        return firstPlayer;
    }
}