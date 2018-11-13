//package WorkWithClasses;
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

    //private static String InfileName = "In.properties";
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
            IWorkWithProperty iWorkWithProperty = new PropertyClass(property.getProperty("FIO"), property.getProperty("DOB"), property.getProperty("email"), property.getProperty("skype"), property.getProperty("avatar"), property.getProperty("target"));
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

