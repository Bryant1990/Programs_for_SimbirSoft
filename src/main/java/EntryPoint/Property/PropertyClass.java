package EntryPoint.Property;/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * @Sibgatullov
 */

import java.util.ArrayList;
import java.util.List;

public class PropertyClass implements IWorkWithProperty {
    private String fio; //ФИО
    private String dob; //Дата рождения
    private String email; //e-mail
    private String skype; //skype
    private String avatar; //аватар
    private String target; //цель

    public PropertyClass(String fio, String dob, String email, String skype, String avatar, String target) {
        this.fio = fio;
        this.avatar = avatar;
        this.dob = dob;
        this.email = email;
        this.skype = skype;
        this.target = target;
    }

    public String getFIO() {
        return fio;
    }

    public String getDOB() {
        return dob;
    }

    public String getEmail() {
        return email;
    }

    public String getSkype() {
        return skype;
    }

    public String getAvatar() {
        return avatar;
    }

    public String getTarget() {
        return target;
    }

    @Override
    public List<String> getPropertyName() {
        List<String> linesOfConfigFile = new ArrayList<>();
        linesOfConfigFile.add(fio + "</p>");
        linesOfConfigFile.add(dob + "</p>");
        linesOfConfigFile.add(email + "</p>");
        linesOfConfigFile.add(skype + "</p>");
        linesOfConfigFile.add(avatar);
        linesOfConfigFile.add(target + "</p>");
        return linesOfConfigFile;
    }
}
