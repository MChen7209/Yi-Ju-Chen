package gui;

import drawing.Drawing;
import drawing.Shape;
import java.awt.Graphics;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import javax.swing.event.MouseInputAdapter;
import java.io.IOException;
import java.lang.Exception;
import java.lang.InstantiationException;
import java.lang.reflect.Constructor;
import java.lang.reflect.ParameterizedType;
import java.util.Optional;
import java.util.Arrays;
import java.util.ArrayList;
import java.util.List;
import javax.swing.DefaultListModel;
import javax.swing.SpinnerNumberModel;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JSpinner;
import javax.swing.WindowConstants;

public class GUI {

    private final JPanel _canvas;
    private final JFrame _mainFrame = new JFrame();
    private final Drawing _drawing = new Drawing();
    private final JMenuBar _menuBar = new JMenuBar();
    private final JMenu _menu = new JMenu("Draw");
    private final DefaultListModel<Shape> _hierarchy = new DefaultListModel<>();

    public GUI() throws IOException, NoSuchFieldException, IllegalAccessException {
        _canvas = new JPanel() {
            @Override
            public void paint(Graphics g) {
                super.paint(g);
                _drawing.shapes.forEach(shape -> {
                    try {
                        getGuiShape(shape).paint(g, shape);
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                });
            }
        };
        
        MouseInputAdapter listener = new MouseInputAdapter() {
            private Optional<Shape> selectedShape = Optional.empty();

            @Override
            public void mousePressed(MouseEvent e) {
                selectedShape = _drawing.getShapeAt(e.getX(), e.getY());
            }

            @Override
            public void mouseReleased(MouseEvent e) {
                selectedShape = Optional.empty();
            }

            @Override
            public void mouseDragged(MouseEvent e) {
                selectedShape.ifPresent(shape -> {
                    _drawing.moveShape(shape, e.getX(), e.getY());
                    _canvas.repaint();
                });
            }
        };

        _canvas.addMouseListener(listener);
        _canvas.addMouseMotionListener(listener);

        Reflections.getAllClassesInClasspaths().stream()
                .filter(klass -> {
                    List<Class> interfaces = Arrays.asList(klass.getInterfaces());
                    return interfaces.contains(GuiShape.class);
                }).forEach(klass -> {
                    try {
                        createNewShapeOption(klass);
                    } catch(Exception ex) {
                        ex.printStackTrace();
                    }
                });

        _mainFrame.add(_canvas);
        _menuBar.add(_menu);
        _mainFrame.setJMenuBar(_menuBar);
        _mainFrame.setBounds(200, 0, 800, 800);
        _mainFrame.setVisible(true);
        _mainFrame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);

        initializeHierarchy();
        initializeInspector();
    }

    private GuiShape getGuiShape(Shape shape) throws Exception {
        String shapeName = shape.getClass().getSimpleName();
        return (GuiShape) Class.forName("gui.Gui" + shapeName).newInstance();
    }

    private void createNewShapeOption(Class klass) throws Exception {
        String shapeName = klass.getSimpleName().replace("Gui", "");
        Class modelClass = (Class) Class.forName("drawing." + shapeName);
        addNewMenuItem(_menu, shapeName, event -> {
            Constructor ctor = modelClass.getConstructors()[0];
            Object[] parameters = new Integer[ctor.getParameterCount()]; 
            for (int i = 0; i < parameters.length; i++) {
                parameters[i] = 100;
            }
        try {
            add((Shape) ctor.newInstance(parameters));
        } catch(Exception e) {
            e.printStackTrace();
        }
        });
    }

    private void initializeHierarchy() {
        JFrame drawingHierarchy = new JFrame();
        JList<Shape> list = new JList<>(_hierarchy);
        drawingHierarchy.add(list);
        drawingHierarchy.setSize(200, 800);
        drawingHierarchy.setVisible(true);
        drawingHierarchy.setDefaultCloseOperation(WindowConstants.DO_NOTHING_ON_CLOSE);
    }
    
    private void initializeInspector() {
        JFrame shapeInspector = new JFrame();
        shapeInspector.setSize(200, 800);
        shapeInspector.setVisible(true);
        shapeInspector.setDefaultCloseOperation(WindowConstants.DO_NOTHING_ON_CLOSE);
       
        JLabel labelName = new JLabel("Object: ");
    }

    /*private void initializeShapeProperties() {
        JFrame shapeProperties = new JFrame();
        SpinnerNumberModel model = new SpinnerNumberModel(50, 0, 800, 1);
        JSpinner sizeField = new JSpinner(model);
        shapeProperties.add(sizeField);
        shapeProperties.setSize(200, 200);
        shapeProperties.setVisible(true);
        shapeProperties.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
    }*/

    private void addNewMenuItem(JMenu menu, String label, ActionListener actionListener) {
        JMenuItem menuItem = new JMenuItem(label);
        menuItem.addActionListener(actionListener);
        menu.add(menuItem);
    }

    private void add(Shape shape) {
        _drawing.add(shape);
        //initializeShapeProperties();
        _mainFrame.repaint();
        _hierarchy.addElement(shape);
    }
}
