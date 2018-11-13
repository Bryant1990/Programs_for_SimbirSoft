
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.*;
import java.util.*;


/**
 * @author Sibgatullov Marat
 */
public class WorkWithClasses implements IWorkWithHTML{


    /**
     * @param args the command line arguments
     */

    private static String InfileName = "C://testforsimbirsoft//In.properties";
    private static String OutfileName = "Out.html";

    public static void main(String[] args) throws FileNotFoundException {
        //Запись в файл                                //Чтение файла
        write(OutfileName, title, target, description, read(InfileName));
    }

    public static void write(String InfileName, String title, String target, String description, List<String> linesOfConfigFile) {
        //Определяем файл
        File file = new File(InfileName);

        try {
            //проверяем, что если файл не существует то создаем его
            if (!file.exists()) {
                file.createNewFile();
            }
            //PrintWriter обеспечит возможности записи в файл
            PrintWriter out = new PrintWriter(file.getAbsoluteFile());
            try {
                //Записываем текст в файл
                Map<String, Integer> exp = new HashMap<>();
                //Map<String, Integer> expSort = new LinkedHashMap<>();
                exp.put("C#", 96);
                //"experience=C#:96,Java:2,Pascal:120,C++:100,C:4"
                exp.put("Java", 2);
                exp.put("Pascal", 120);
                exp.put("C++", 100);
                exp.put("C", 4);
                String expInHTML = "";
                int expSize = exp.size();
                for (int i = 0; i < expSize; i++){
                    int max = 0;
                    String keyMax = "";
                    for (Map.Entry<String, Integer> entry : exp.entrySet()){
                        if (entry.getValue() > max){
                            max = entry.getValue();
                            keyMax = entry.getKey();
                        }
                    }
                    expInHTML += keyMax;
                    expInHTML += ":";
                    expInHTML += max;
                    if (i != expSize - 1){
                        expInHTML += ",";
                    }
                    exp.remove(keyMax);
                }
                linesOfConfigFile.add(2, telephoneNumber);
                List<String> mainWordsInResume = new ArrayList<>();
                mainWordsInResume.add(fioInTable);
                mainWordsInResume.add(dobInTable);
                mainWordsInResume.add(telInTable);
                mainWordsInResume.add(emailInTable);
                mainWordsInResume.add(skypeInTable);
                List<OutStringToPrint> outStringToPrint = new ArrayList<>();
                outStringToPrint.add(new OutStringToPrint(title));
                outStringToPrint.add(new OutStringToPrint(pictureInTableBegin + linesOfConfigFile.get(5) + pictureInTableEnd));
                for (int i = 0; i < mainWordsInResume.size(); i++)
                    outStringToPrint.add(new OutStringToPrint(mainWordsInResume.get(i) + linesOfConfigFile.get(i)));
                outStringToPrint.add(new OutStringToPrint(target));
                outStringToPrint.add(new OutStringToPrint(linesOfConfigFile.get(6)));
                outStringToPrint.add(new OutStringToPrint(description));
                outStringToPrint.add(new OutStringToPrint(expInHTML));
                //for (int i = 0; i < outStringToPrint.size(); i++)
                for (OutStringToPrint i: outStringToPrint)
                    out.print(i.getName());
            } finally {
                //После чего мы должны закрыть файл
                //Иначе файл не запишется
                out.close();
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static List<String> read(String InfileName) throws FileNotFoundException {
        exists(InfileName);
        try {
            File f = new File(InfileName);
            Reader reader = new InputStreamReader(new FileInputStream(f), "Cp1251");
            Properties property = new Properties();
            property.load(reader);
            Map<String, String> propertyInMap = new HashMap<>();
            propertyInMap.put("FIO", property.getProperty("FIO"));
            propertyInMap.put("DOB", property.getProperty("DOB"));
            propertyInMap.put("email", property.getProperty("email"));
            propertyInMap.put("skype", property.getProperty("skype"));
            propertyInMap.put("avatar", property.getProperty("avatar"));
            propertyInMap.put("target", property.getProperty("target"));
            IWorkWithProperty iWorkWithProperty = new PropertyClass(propertyInMap.get("FIO"), propertyInMap.get("DOB"), propertyInMap.get("email"), propertyInMap.get("skype"), propertyInMap.get("avatar"), propertyInMap.get("target"));
            return iWorkWithProperty.getPropertyName(InfileName);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }


    }

    private static void exists(String InfileName) throws FileNotFoundException {
        File file = new File(InfileName);
        if (!file.exists()) {
            throw new FileNotFoundException(file.getName());
        }
    }
}
