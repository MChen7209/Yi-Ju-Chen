package drawing;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class Drawing {

    public final List<Shape> shapes = new ArrayList<>();

    public void add(Shape drawing) {
        shapes.add(0, drawing);
    }

    public Optional<Shape> getShapeAt(int x, int y) {
        return shapes.stream()
                .filter(shape -> shape.containsPoint(x, y))
                .findFirst();
    }

    public void moveShape(Shape shape, int x, int y) {
    	shape.setX(x);
    	shape.setY(y);
    }
}
