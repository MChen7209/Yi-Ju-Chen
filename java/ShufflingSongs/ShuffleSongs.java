import java.util.*;
import java.util.stream.*;
import java.util.List;
import java.util.ArrayList;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.FileReader;
import java.util.Scanner;
    
class ShuffleSongs {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in); 
        do {
            System.out.println("Enter file name: ");
            String fileName = input.next();
            try {
                List<String> songList = getSongList(fileName);

                //Inverting songs
                System.out.println("Inverse Songs Using Collect:  " + invertSongsCollect(songList));
                System.out.println("Inverse Songs using Recursion:" + invertSongsRecursive(songList));

                //Using built in shuffle in collections.
                Collections.shuffle(songList);
                System.out.println("Shuffle Songs Using Built In: " + songList);
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }

            System.out.print("Again? (n to quit): ");
        } while (!input.next().equals("n"));
    }
    
    static List<String> getSongList(String fileName) throws Exception {
        //Use file reader to get a list of songs copy and pasted in a notepad or something.
        List<String> songList = new ArrayList<String>();
        String currentLine = null;
        try {
            BufferedReader reader = new BufferedReader(new FileReader(fileName));
            while ((currentLine = reader.readLine()) != null) {
                songList.add(currentLine);
            }
        } catch (Exception e) {
            throw new Exception("File Not Found");
        }
        return songList;
    }

    static List<String> invertSongsRecursive(List<String> songList) {
        if(songList.size() <= 1)
            return songList;
        return Stream.concat(invertSongsRecursive(songList.subList(1, songList.size())).stream(), Arrays.asList(songList.get(0)).stream()).collect(Collectors.toList());
    }

    static List<String> invertSongsCollect(List<String> songList) {
        //Last in first out using linked lists
        return songList.stream()
            .collect(LinkedList::new, LinkedList::addFirst, LinkedList::addAll);
    }
}
