# Тестовые задания для разработчика / Web

### 1. Описание задания

Дана форма следующего вида (HTML-код формы приведен ниже):

Разработайте веб-приложение, которое будет отправлять данные формы на сервер используя AJAX. При этом вы можете использовать любой Javascript-фреймворк по своему желанию (jQuery и т.п.). 
Данные должны валидироваться на сервере (не пустое имя, выбрано любимое время дня и т.п.) и если данные валидны, должна отображаться страница с введенными данными.

_HTML-код формы:_
```sh
<table>
            <tr>
                <td>
                    <label for="name">Your name:</label></td>
                <td>
                    <input type="text" id="name" /></td>
            </tr>
            <tr>
                <td>
                    <label for="color">Your favourite color:</label></td>
                <td>
                    <select id="color">
                        <option>Green</option>
                        <option>Red</option>
                        <option>Yellow</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="18-years">You are older than 18 years</label></td>
                <td>
                    <input type="checkbox" id="18-years" /></td>
            </tr>
            <tr>
                <td>Your favourite time of day:</td>
                <td>
                    <input type="radio" id="radio-morning" name="daytime" />
                    <label for="radio-morning">Morning</label>
                    <br />
                    <input type="radio" id="radio-evening" name="daytime" />
                    <label for="radio-evening">Evening</label>
                    <br />
                    <input type="radio" id="radio-night" name="daytime" />
                    <label for="radio-night">Night</label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="submit" value="Send" />
                </td>
            </tr>
        </table>
```
Удачи!
### 2. Контакты

E-mail: hr@mmtr.ru
Сайт: www.mmtr.ru 

