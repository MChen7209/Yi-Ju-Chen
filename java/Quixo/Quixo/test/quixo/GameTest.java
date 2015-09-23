package quixo;

import junit.framework.TestCase;
import static org.junit.Assert.*;
import quixo.Game.Direction;
import quixo.Game.FaceType;

public class GameTest extends TestCase
{
    Game game;
    
    protected void setUp()
    {
        game = new Game();
        game.setCurrentPlayer(FaceType.X);
    }
    
    public void testMoveTopLeftCornerCubeRight()
    {
        game.moveCube(0,0,Direction.RIGHT);
        assertEquals(FaceType.BLANK, game.getFaceType(0, 0));
        assertNotEquals(FaceType.BLANK, game.getFaceType(4, 0));
    }
    
    public void testMoveTopRightCornerCubeLeft()
    {
        game.moveCube(4,0,Direction.LEFT);
        assertEquals(FaceType.BLANK, game.getFaceType(4, 0));
        assertNotEquals(FaceType.BLANK, game.getFaceType(0, 0));
    }
    
    public void testMoveBottomLeftCornerCubeUp()
    {
        game.moveCube(0,4,Direction.UP);
        assertEquals(FaceType.BLANK, game.getFaceType(0, 4));
        assertNotEquals(FaceType.BLANK, game.getFaceType(0, 0));
    }
    
    public void testMoveTopLeftCornerCubeDown()
    {
        game.moveCube(0,0,Direction.DOWN);
        assertEquals(FaceType.BLANK, game.getFaceType(0, 0));
        assertNotEquals(FaceType.BLANK, game.getFaceType(0, 4));
    }

    public void testMoveEdgeCubeDown()
    {
        game.moveCube(2,0,Direction.DOWN);
	assertEquals(FaceType.BLANK, game.getFaceType(2,0));
	assertNotEquals(FaceType.BLANK, game.getFaceType(2,4));
    }

    public void testMoveEdgeCubeRight()
    {
	game.moveCube(2,0,Direction.RIGHT);
	assertEquals(FaceType.BLANK,game.getFaceType(2,0));
	assertNotEquals(FaceType.BLANK,game.getFaceType(4,0));
    }

    public void testMoveMiddleCubeRight()
    {
	game.moveCube(2,2,Direction.RIGHT);
	assertEquals(FaceType.BLANK, game.getFaceType(2,2));
	assertFalse(game.getFaceType(4,2)!=FaceType.BLANK);
    }

    public void testMoveCubeTwice()
    {
	game.moveCube(4,4,Direction.UP);
	game.moveCube(4,4,Direction.UP);
	assertNotEquals(FaceType.BLANK,game.getFaceType(4,0));
	assertNotEquals(FaceType.BLANK,game.getFaceType(4,1));
	assertNotEquals(game.getFaceType(4,0),game.getFaceType(4,1));
    }

    public void testMoveOpponentCube()
    {
	game.moveCube(4,4,Direction.UP);
	game.moveCube(4,0,Direction.DOWN);
	assertEquals(FaceType.BLANK, game.getFaceType(4,4));
	assertNotEquals(FaceType.BLANK, game.getFaceType(4,0));
    }

    public void testCheckColumnVictory()
    {
        game.moveCube(0,0,Direction.DOWN);
	game.moveCube(2,0,Direction.DOWN);
	game.moveCube(0,0,Direction.DOWN);
	game.moveCube(3,0,Direction.DOWN);
	game.moveCube(0,0,Direction.DOWN);
	game.moveCube(4,0,Direction.DOWN);
	game.moveCube(0,0,Direction.DOWN);
	game.moveCube(1,0,Direction.DOWN);
	game.moveCube(0,0,Direction.DOWN);
	assertEquals(FaceType.X, game.checkVictory());
    }

    public void testCheckRowVictory()
    {
	game.moveCube(0,4,Direction.RIGHT);
	game.moveCube(0,0,Direction.RIGHT);
	game.moveCube(0,3,Direction.RIGHT);
	game.moveCube(0,0,Direction.RIGHT);
	game.moveCube(0,2,Direction.RIGHT);
	game.moveCube(0,0,Direction.RIGHT);
	game.moveCube(0,1,Direction.RIGHT);
	game.moveCube(0,0,Direction.RIGHT);
	game.moveCube(0,4,Direction.RIGHT);
	game.moveCube(0,0,Direction.RIGHT);
	assertEquals(FaceType.O, game.checkVictory());
    }

    public void testCheckDiagonalVictory()
    {
	game.moveCube(0,0,Direction.DOWN);
	game.moveCube(4,0,Direction.LEFT);
	game.moveCube(4,4,Direction.UP);
	game.moveCube(0,1,Direction.UP);
	game.moveCube(1,0,Direction.DOWN);
	game.moveCube(0,1,Direction.UP);
	game.moveCube(1,0,Direction.DOWN);
	game.moveCube(0,1,Direction.UP);
	game.moveCube(3,4,Direction.UP);
	game.moveCube(0,1,Direction.UP);
	game.moveCube(3,4,Direction.UP);
	game.moveCube(0,1,Direction.UP);
	game.moveCube(3,4,Direction.UP);
	game.moveCube(0,1,Direction.UP);
	game.moveCube(0,2,Direction.RIGHT);
	assertEquals(FaceType.X, game.checkVictory());
    }

    public void testCheckWinnerIfBothWin()
    {
	game.moveCube(0,4,Direction.UP);
	game.moveCube(4,4,Direction.UP);
	game.moveCube(0,4,Direction.UP);
	game.moveCube(4,4,Direction.UP);
	game.moveCube(0,4,Direction.UP);
	game.moveCube(4,4,Direction.UP);
	game.moveCube(0,4,Direction.UP);
	game.moveCube(4,4,Direction.UP);
	game.moveCube(1,0,Direction.DOWN);
	game.moveCube(0,4,Direction.RIGHT);
	assertEquals(FaceType.X, game.checkVictory());		
    }       
}