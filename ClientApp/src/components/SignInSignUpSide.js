﻿import React from 'react';
import Avatar from '@material-ui/core/Avatar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import LoginForm from "./account/LoginForm";
import RegisterForm from "./account/RegisterForm";
import { Container } from 'reactstrap';
import './Main.css';

const useStyles = makeStyles(theme => ({
  root: {
    height: '100%',
  },
  main: {
    marginBottom: '20px',
  },
  image: {
    backgroundImage: 'url(https://source.unsplash.com/random)',
    backgroundRepeat: 'no-repeat',
    backgroundColor:
      theme.palette.type === 'dark' ? theme.palette.grey[900] : theme.palette.grey[50],
    backgroundSize: 'cover',
    backgroundPosition: 'center',
  },
  paper: {
    margin: theme.spacing(8, 4),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

export default function SignInSignUpSide({ match, titleForm }) {
    const classes = useStyles();

  return (
    <section className="documentBody d-flex flex-column justify-content-center">
      <Container>
        <Grid container component="main" className={classes.root}>
          <CssBaseline />
          <Grid item xs={false} sm={4} md={7} className={classes.image} />
          <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
            <div className={classes.paper}>
              <Avatar className={classes.avatar}>
                <LockOutlinedIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                {titleForm}
                      </Typography>
                      {match.path === "/login" &&
                          <LoginForm
                              classes={classes}
                          />
                      }
                      {match.path === "/register" &&
                          <RegisterForm
                              classes={classes}
                          />
                      }
            </div>
          </Grid>
        </Grid>
      </Container>
    </section>
  );
}