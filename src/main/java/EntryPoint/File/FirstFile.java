package EntryPoint.File;

import org.springframework.stereotype.Component;

@Component
public class FirstFile implements FileReadable{
    private String fileName;

    public FirstFile(){this.fileName = "C://testforsimbirsoft//1.properties";}

    @Override
    public String getFileName(){
        return fileName;
    }
}
