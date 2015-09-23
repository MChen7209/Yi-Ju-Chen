package drawing;

import java.awt.Point;
import java.util.ArrayList;
import java.util.List;
import static org.junit.Assert.*;
import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;

@Ignore
public abstract class ShapeTest {

    private Shape _shape;
    private Drawing _drawing;

    public abstract Shape createShape();

    public abstract List<Point> createPositivePoints();

    public abstract List<Point> createNegativePoints();

    public abstract boolean checkDimensions();

    @Before
    public void setUp() {
        _shape = createShape();
        _drawing = new Drawing();
    }

    @Test
    public void testValidateDimensions() {
        assertTrue(checkDimensions());
    }

    @Test
    public void testPositivePoints() {
        createPositivePoints().forEach(point -> {
            assertTrue(_shape.containsPoint(point.x, point.y));
        });
    }

    @Test
    public void testNegativePoints() {
        createNegativePoints().forEach(point -> {
            assertFalse(_shape.containsPoint(point.x, point.y));
        });
    }

    @Test
    public void testMoveShape() {
        _drawing.add(_shape);
        _drawing.moveShape(_shape, 300, 300);
        assertEquals(300, _shape.getX());
        assertEquals(300, _shape.getY());
    }
    
    protected List<Point> createPoints(List<Integer> xPoints, List<Integer> yPoints) {
        List<Point> points = new ArrayList<>();
        for (int i = 0; i < xPoints.size(); i++) {
            points.add(new Point(xPoints.get(i), yPoints.get(i)));
        }
        return points;
    }
}
