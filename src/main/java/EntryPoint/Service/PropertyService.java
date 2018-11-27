package EntryPoint.Service;
import EntryPoint.Property.Reader.PropertyReader;
import EntryPoint.Property.Reader.PropertyReader2;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.Map;

/**
 *
 * @author m.sibgatullov
 */
@Component
public class PropertyService {
    @Autowired
    private PropertyReader propertyReader;
    @Autowired
    private PropertyReader2 propertyReader2;

    public Map<String, String> readData1() {
           return propertyReader.getMap();
    }
    public Map<String, String> readData2() {
        return propertyReader2.getMap();
    }
}

