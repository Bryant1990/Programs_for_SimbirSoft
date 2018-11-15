import java.io.*;
import java.util.*;

        /*
         * To change this license header, choose License Headers in Project Properties.
         * To change this template file, choose Tools | Templates
         * and open the template in the editor.
         */

/**
 *
 * @author Sibgatullov Marat
 */
public class PropertyReader extends Thread {
    private String inFileName;
    private Map<String, String> propertyInMap;

    public PropertyReader(String inFileName, Map<String, String> propertyInMap){
        this.inFileName = inFileName;
        this.propertyInMap = propertyInMap;
    }
    @Override
    public void run(){
        readProperty();
    }

    public void readProperty(){
        try{
            File f = new File(inFileName);
            Reader reader = new InputStreamReader(new FileInputStream(f), "Cp1251");
            Properties property = new Properties();
            property.load(reader);
            switch (inFileName){
                case "C://testforsimbirsoft//1.properties":
                    propertyInMap.put("FIO", property.getProperty("FIO"));
                    propertyInMap.put("DOB", property.getProperty("DOB"));
                    propertyInMap.put("email", property.getProperty("email"));
                    break;
                case "C://testforsimbirsoft//2.properties":
                    propertyInMap.put("skype", property.getProperty("skype"));
                    propertyInMap.put("avatar", property.getProperty("avatar"));
                    propertyInMap.put("target", property.getProperty("target"));
                    break;
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}

