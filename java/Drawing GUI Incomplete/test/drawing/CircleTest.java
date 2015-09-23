package drawing;

import java.awt.Point;
import static org.junit.Assert.*;
import org.junit.Test;
import java.util.Arrays;
import java.util.List;

public class CircleTest extends ShapeTest {

    private Circle _circle;

    @Override
    public Circle createShape() {
        return _circle = new Circle(100, 100, 50);
    }

    @Override
    public List<Point> createPositivePoints() {
        List<Integer> xPoints = Arrays.asList(75, 75, 75, 100, 100, 100, 125, 125, 125);
        List<Integer> yPoints = Arrays.asList(75, 100, 125, 75, 100, 125, 75, 100, 125);
        return createPoints(xPoints, yPoints);
    }

    @Override
    public List<Point> createNegativePoints() {
        List<Integer> xPoints = Arrays.asList(50, 50, 50, 100, 100, 150, 150, 150);
        List<Integer> yPoints = Arrays.asList(50, 100, 150, 50, 150, 50, 100, 150);
        return createPoints(xPoints, yPoints);
    }

    @Override
    public boolean checkDimensions() {
        return _circle.getRadius() == 50;
    }
}
