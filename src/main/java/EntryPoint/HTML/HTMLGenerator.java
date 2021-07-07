package EntryPoint.HTML;

import EntryPoint.Print.OutStringToPrint;
import EntryPoint.Service.PropertyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 *
 * @author m.sibgatullov
 */
@Component
public class HTMLGenerator implements IWorkWithHTML {

    private PropertyService propertyService;
    private String outFileName = "C://testforsimbirsoft//Out.html";

    @Autowired
    public HTMLGenerator(PropertyService propertyService){
        this.propertyService = propertyService;
    }

    public Map<String, String> getData1() {
        return propertyService.readData1();
    }

    public Map<String, String> getData2() {
        return propertyService.readData2();
    }

    public void generateHTML(List<String> linesOfConfigFile){
        File file = new File(outFileName);
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
                exp.put("C#", 96);
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
}
