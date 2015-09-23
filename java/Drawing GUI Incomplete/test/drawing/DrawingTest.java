package drawing;

import java.util.Optional;
import org.junit.Before;
import static org.junit.Assert.*;
import org.junit.Test;

public class DrawingTest {

    private Drawing _drawing;

    @Before
    public void setUp() {
        _drawing = new Drawing();
    }

    @Test
    public void testAddShape() {
        assertEquals(0, _drawing.shapes.size());
        Circle circle = new Circle(50, 50, 50);
        _drawing.add(circle);
        assertEquals(1, _drawing.shapes.size());
    }

    @Test
    public void testSelectShape() {
        Circle circle = new Circle(50, 50, 50);
        _drawing.add(circle);
        assertEquals(circle, _drawing.getShapeAt(50, 50).get());
    }

    @Test
    public void testSelectMostRecentlyAddedOverlappingShape() {
        Circle circle = new Circle(50, 50, 50);
        Rectangle rectangle = new Rectangle(0, 0, 100, 100);
        _drawing.add(circle);
        _drawing.add(rectangle);
        assertEquals(rectangle, _drawing.getShapeAt(50, 50).get());
    }

    @Test
    public void testSelectNothing() {
        Circle circle = new Circle(50, 50, 50);
        _drawing.add(circle);
        assertEquals(Optional.empty(), _drawing.getShapeAt(0, 0));
    }
}
