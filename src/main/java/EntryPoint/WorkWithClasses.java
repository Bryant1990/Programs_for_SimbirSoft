package EntryPoint;/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import EntryPoint.File.FirstFile;
import EntryPoint.File.SecondFile;
import EntryPoint.HTML.HTMLGenerator;
import EntryPoint.Property.IWorkWithProperty;
import EntryPoint.Property.PropertyClass;
import EntryPoint.Property.Reader.PropertyReader;
import EntryPoint.Property.Reader.PropertyReader2;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import java.io.File;
import java.io.FileNotFoundException;
/**
 * @author Sibgatullov Marat
 */
@SpringBootApplication
public class WorkWithClasses {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws FileNotFoundException, InterruptedException {
        //Запись в файл                               //Чтение файла
        ConfigurableApplicationContext context = SpringApplication.run(WorkWithClasses.class);
        FirstFile firstFile = context.getBean(FirstFile.class);
        exists(firstFile.getFileName());
        SecondFile secondFile = context.getBean(SecondFile.class);
        exists(secondFile.getFileName());
        Thread firstPropertyFile = context.getBean(PropertyReader.class);
        Thread secondPropertyFile = context.getBean(PropertyReader2.class);
        firstPropertyFile.start();
        secondPropertyFile.start();
        firstPropertyFile.join();
        secondPropertyFile.join();
        HTMLGenerator bean = context.getBean(HTMLGenerator.class);
        IWorkWithProperty iWorkWithProperty = new PropertyClass(bean.getData1().get("FIO"), bean.getData1().get("DOB"), bean.getData1().get("email"), bean.getData2().get("skype"), bean.getData2().get("avatar"), bean.getData2().get("target"));
        bean.generateHTML(iWorkWithProperty.getPropertyName());
    }

    private static void exists(String InfileName) throws FileNotFoundException {
        File file = new File(InfileName);
        if (!file.exists()) {
            throw new FileNotFoundException(file.getName());
        }
    }
}
