package drawing;

public interface Shape {

    boolean containsPoint(int x, int y);

    int getX();

    void setX(int x);

    int getY();

    void setY(int x);
}
