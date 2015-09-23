package gui;

import drawing.Shape;
import drawing.Circle;
import java.awt.Graphics;

public class GuiCircle implements GuiShape {

    @Override
    public void paint(Graphics graphics, Shape circle) {
        Circle _circle = (Circle)circle;
        int radius = _circle.getRadius();
        graphics.drawOval(_circle.getX() - radius, _circle.getY() - radius, radius * 2, radius * 2);
    }
}
