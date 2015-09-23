package gui;

import drawing.Shape;
import java.awt.Graphics;

public interface GuiShape {
    void paint(Graphics graphics, Shape shape);
}
