import java.util.*;
import java.util.stream.*;
import java.util.List;
import java.util.ArrayList;
import java.util.function.IntPredicate;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.FileReader;
    
class ShuffleSongs {
    public static void main(String[] args) {
        // List<Integer> test = IntStream.rangeClosed(1,20)
        //                                .boxed()
        //                                  .collect(Collectors.toList());
        ArrayList<String> songList = getSongList("songFile.txt");
        Collections.shuffle(songList);
        System.out.println(songList);
        // Collections.shuffle(test);
//         System.out.println(test);
    }
    
    static ArrayList<String> getSongList(String fileName) {
        //Use file reader to get a list of songs copy and pasted in a notepad or something.
        ArrayList<String> songList = new ArrayList<String>();
        String currentLine = null;
        try {
            BufferedReader reader = new BufferedReader(new FileReader(fileName));
            while ((currentLine = reader.readLine()) != null) {
                songList.add(currentLine);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return songList;
    }
}
