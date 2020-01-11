import React, { useState } from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Box from '@material-ui/core/Box';
import Copyright from "../common/Copyright";
import FormControl from '@material-ui/core/FormControl';
import FormHelperText from '@material-ui/core/FormHelperText';
import { withRouter } from "react-router";

function RegisterForm({ classes, history }) {
    const [email, setEmail] = useState(
        {
            value: "",
            valid: false,
            helperText: ""
        }
    );

    const [password, setPassword] = useState(
        {
            value: "",
            valid: false,
            helperText: ""
        }
    );

    const [repeatPassword, setRepeatPassword] = useState(
        {
            value: "",
            valid: false,
            helperText: ""
        }
    );

    const [name, setName] = useState();
    const [surname, setSurname] = useState();
    const [address, setAddress] = useState();

    const [conditions, setConditions] = useState({
        value: false,
        helperText: ""
    });

    function sendForm() {
        if (email.value.length > 0 && password.value.length > 0 && password.value === repeatPassword.value && conditions.value) {  
            var registerModel = {
                email: email["value"],
                password: password["value"],
                name: name,
                surname: surname,
                address: address
            }
            
            fetch("api/user", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(registerModel)
            })
                .then(resp => resp.json())
                .then(resp => {
                    console.log(resp);
                    resp ? history.push("/login") :
                        alert("Błąd! Użytkownik nie został zarejestrowany!");
                });
        } else {
            console.log(history);
            checkForm();
        }

    }

    function checkForm() {
        if (email.value.length === 0) {
            setEmail({
                ...email,
                valid: true,
                helperText: "Adres email jest obowiąkowy!"
            })
        } else {
            setEmail({
                ...email,
                valid: false,
                helperText: ""
            })
        }
        if (password.value.length === 0) {
            setPassword({
                ...password,
                valid: true,
                helperText: "Podaj hasło!"
            })
            setRepeatPassword({
                ...repeatPassword,
                valid: true,
                helperText: "Powtórz hasło!"
            })
        } else {
            setPassword({
                ...password,
                valid: false,
                helperText: ""
            })
        }
        if (password.valid) {
            if (repeatPassword.value !== password.value) {
                setRepeatPassword({
                    ...repeatPassword,
                    valid: true,
                    helperText: "Hasłą muszą być takie same!"
                })
            } else {
                setRepeatPassword({
                    ...repeatPassword,
                    valid: false,
                    helperText: ""
                })
            }
        }
        if (!conditions.value) {
            setConditions({
                ...conditions,
                helperText: "Zaakceptuj warunki!"
            })
        } else {
            setConditions({
                ...conditions,
                helperText: ""
            })
        }
    }

    return (
        <form className={classes.form} noValidate>
            <TextField
                error={email.valid}
                variant="outlined"
                margin="normal"
                fullWidth
                id="email"
                label="Adres e-mail"
                name="email"
                helperText={email.helperText}
                onChange={(e) => setEmail({
                    ...email,
                    value: e.target.value
                })}
                autoComplete="email"
                autoFocus
            />
            <TextField
                error={password.valid}
                variant="outlined"
                margin="normal"
                fullWidth
                name="password"
                label="Hasło"
                type="password"
                helperText={password.helperText}
                onChange={(e) => setPassword({
                    ...password,
                    value: e.target.value
                })}
                id="password"
                autoComplete="current-password"
            />
            <TextField
                error={repeatPassword.valid}
                variant="outlined"
                margin="normal"
                fullWidth
                name="repeatPassword"
                label="Powtórz hasło"
                type="password"
                helperText={repeatPassword.helperText}
                onChange={(e) => setRepeatPassword({
                    ...repeatPassword,
                    value: e.target.value
                })}
                id="repeatPassword"
                autoComplete="current-password"
            />
            <TextField
                variant="outlined"
                margin="normal"
                fullWidth
                name="name"
                label="Imię"
                type="test"
                onChange={(e) => setName(e.target.value)}
                id="name"
            />
            <TextField
                variant="outlined"
                margin="normal"
                fullWidth
                id="surname"
                label="Nazwisko"
                name="surname"
                onChange={(e) => setSurname(e.target.value)}
                type="text"
            />
            <TextField
                variant="outlined"
                margin="normal"
                fullWidth
                name="address"
                label="Adres"
                type="text"
                onChange={(e) => setAddress(e.target.value)}
                id="password"
            />
            
            <FormControl required error={!conditions.value}>
                <FormControlLabel
                    control={<Checkbox onChange={(e) => setConditions({
                        helperText: "",
                        value: e.target.checked
                    })} value="remember" color="primary"
                    
                />}
                label="Akceptuję warunki"
                />
                <FormHelperText>{conditions.helperText}</FormHelperText>
            </FormControl>
            <Button
                type="button"
                fullWidth
                variant="contained"
                color="primary"
                onClick={sendForm}
                className={classes.submit}
            >
                Zarejestruj się
            </Button>
            <Box mt={5}>
                <Copyright />
            </Box>
        </form>
    );
}

export default (withRouter)(RegisterForm);