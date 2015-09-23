package gui;

import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Reflections {

    public static List<Class> getAllClassesInClasspaths() throws IOException {
        List<Class> result = new ArrayList<>();
        for (URL url : Collections.list(ClassLoader.getSystemResources(""))) {
            Path path = new File(url.getPath()).toPath();
            getAllFilesInDir(path.toString().replaceAll("%20", " ")).stream()
                    .forEach(file -> {
                        String filePath = file.toString();
                        if (filePath.endsWith(".class")) {
                            String className = filePath
                            .replaceFirst(".*classes\\" + File.separator, "")
                            .replaceFirst(".*main\\" + File.separator, "")
                            .replaceAll("\\" + File.separator, ".")
                            .replace(".class", "");
                            try {
                                result.add(Class.forName(className));
                            } catch (ClassNotFoundException ex) {
                                Logger.getLogger(GUI.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        }
                    });
        }
        return result;
    }

    private static List<File> getAllFilesInDir(String directoryName) {
        File directory = new File(directoryName);
        List<File> resultList = new ArrayList<>();
        for (File file : directory.listFiles()) {
            if (file.isFile()) {
                resultList.add(file);
            } else if (file.isDirectory()) {
                resultList.addAll(getAllFilesInDir(file.getAbsolutePath()));
            }
        }
        return resultList;
    }
}
