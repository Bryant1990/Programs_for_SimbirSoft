package EntryPoint.File;

import org.springframework.stereotype.Component;

@Component
public class SecondFile implements FileReadable {
    private String fileName;

        public SecondFile(){this.fileName = "C://testforsimbirsoft//2.properties";}

    @Override
    public String getFileName(){
        return fileName;
    }
}
