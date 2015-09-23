package drawing;

public class Circle implements Shape {

    private int _x, _y, _radius;

    public Circle(int x0, int y0, int radius0) {
        _x = x0;
        _y = y0;
        _radius = radius0;
    }

    @Override
    public boolean containsPoint(int x1, int y1) {
        int dx = _x - x1;
        int dy = _y - y1;
        int distSquared = dx * dx + dy * dy;
        return distSquared < _radius * _radius;
    }

    @Override
    public int getX() {
        return _x;
    }

    @Override
    public void setX(int x) {
        _x = x;
    }

    @Override
    public int getY() {
        return _y;
    }

    @Override
    public void setY(int y) {
        _y = y;
    }

    public int getRadius() {
        return _radius;
    }
}
