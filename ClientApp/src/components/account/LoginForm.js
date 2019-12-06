import React, { useState } from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Box from '@material-ui/core/Box';
import Grid from '@material-ui/core/Grid';
import Copyright from "../common/Copyright";

export default function LoginForm({ classes }) {
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

    function sendForm() {
        if (email.value.length > 0 && password.value.length > 0) {
            console.log("send");
        } else {
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
        } else {
            setPassword({
                ...password,
                valid: false,
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
            <FormControlLabel
                control={<Checkbox value="remember" color="primary" />}
                label="Zapamiętaj mnie"
            />
            <Button
                type="button"
                fullWidth
                variant="contained"
                color="primary"
                onClick={sendForm}
                className={classes.submit}
            >
                Zaloguj się
            </Button>
            <Grid container>
                <Grid item xs>
                    <Link href="#" variant="body2">
                        Zapomniałeś hasła?
                </Link>
                </Grid>
                <Grid item>
                    <Link href="#" variant="body2">
                        {"Nie masz konta? Zarejestruj się"}
                    </Link>
                </Grid>
            </Grid>
            <Box mt={5}>
                <Copyright/>
            </Box>
        </form>
        );
}