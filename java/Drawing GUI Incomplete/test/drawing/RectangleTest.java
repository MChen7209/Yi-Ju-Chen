package drawing;

import java.awt.Point;
import static org.junit.Assert.*;
import org.junit.Test;
import java.util.Arrays;
import java.util.List;

public class RectangleTest extends ShapeTest {

    private Rectangle _rectangle;

    @Override
    public Rectangle createShape() {
        return _rectangle = new Rectangle(100, 100, 100, 100);
    }

    @Override
    public List<Point> createPositivePoints() {
        List<Integer> xPoints = Arrays.asList(125, 125, 125, 150, 150, 150, 175, 175, 175);
        List<Integer> yPoints = Arrays.asList(125, 150, 175, 125, 150, 175, 125, 150, 175);
        return createPoints(xPoints, yPoints);
    }

    @Override
    public List<Point> createNegativePoints() {
        List<Integer> xPoints = Arrays.asList(0, 0, 150, 150, 300, 300, 0);
        List<Integer> yPoints = Arrays.asList(0, 150, 0, 300, 150, 300, 300);
        return createPoints(xPoints, yPoints);
    }

    @Override
    public boolean checkDimensions() {
        return (_rectangle.getWidth() == 100)&&(_rectangle.getHeight() == 100);
    }
}
