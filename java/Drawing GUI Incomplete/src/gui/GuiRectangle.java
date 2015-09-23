package gui;

import drawing.Shape;
import drawing.Rectangle;
import java.awt.Graphics;

public class GuiRectangle implements GuiShape {

    @Override
    public void paint(Graphics graphics, Shape rectangle) {
    	Rectangle _rectangle = (Rectangle) rectangle;
        graphics.drawRect(_rectangle.getX(), _rectangle.getY(), _rectangle.getWidth(), _rectangle.getHeight());
    }
}
