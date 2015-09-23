package drawing;

public class Rectangle implements Shape {

    private int _x, _y, _width, _height;

    public Rectangle(int left, int top, int width0, int height0) {
        _x = left;
        _y = top;
        _width = width0;
        _height = height0;
    }

    @Override
    public boolean containsPoint(int x1, int y1) {
        return x1 > _x && y1 > _y && x1 < _x + _width && y1 < _y + _height;
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

    public int getWidth() {
        return _width;
    }

    public int getHeight() {
        return _height;
    }
}
