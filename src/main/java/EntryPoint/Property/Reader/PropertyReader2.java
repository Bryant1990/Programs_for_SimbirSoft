package EntryPoint.Property.Reader;

import EntryPoint.File.FileReadable;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;

import java.io.*;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;

        /*
         * To change this license header, choose License Headers in Project Properties.
         * To change this template file, choose Tools | Templates
         * and open the template in the editor.
         */

/**
 *
 * @author Sibgatullov Marat
 */
@Component
public class PropertyReader2 extends Thread {

    @Autowired
    @Qualifier("secondFile")
    private FileReadable fileReadable;
    private Map<String, String> propertyInMap = new HashMap<>();

    public Map<String, String> getMap(){
        return propertyInMap;
    }

    @Override
    public void run(){
        readProperty();
    }

    public void readProperty(){
        try{
            File f = new File(fileReadable.getFileName());
            Reader reader = new InputStreamReader(new FileInputStream(f), "Cp1251");
            Properties property = new Properties();
            property.load(reader);
            switch (fileReadable.getFileName()){
                case "C://testforsimbirsoft//1.properties":
                    propertyInMap.put("FIO", property.getProperty("FIO"));
                    propertyInMap.put("DOB", property.getProperty("DOB"));
                    propertyInMap.put("email", property.getProperty("email"));
                    break;
                case "resources/2.properties":
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