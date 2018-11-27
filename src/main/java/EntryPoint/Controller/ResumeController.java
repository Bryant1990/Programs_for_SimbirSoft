package EntryPoint.Controller;

import EntryPoint.HTML.HTMLGenerator;
import EntryPoint.Service.PropertyService;
import EntryPoint.WorkWithClasses;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;


@Controller
public class ResumeController {

    @Autowired
    PropertyService service;

    @Autowired
    HTMLGenerator htmlGenerator;

    @GetMapping("/resume")
    public String getResume(Model model) {
        model.addAttribute("fio", service.readData1().get("FIO"));
        model.addAttribute("dob", service.readData1().get("DOB"));
        model.addAttribute("email", service.readData1().get("email"));
        model.addAttribute("skype", service.readData2().get("skype"));
        model.addAttribute("avatar", service.readData2().get("avatar"));
        model.addAttribute("target", service.readData2().get("target"));
        model.addAttribute("exp", htmlGenerator.getExpInHTML());
        return "resume";
    }
}
