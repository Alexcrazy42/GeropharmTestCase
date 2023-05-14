import React, { Component, useState, useEffect, useRef } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import styles from './Home.module.css';
import './Home.css';
import { render } from 'react-dom';
import { CSSTransition, TransitionGroup } from 'react-transition-group'
import { Table, Head, Body, Row, Cell } from './Table/Table.js'







const Slide = ({ children, ...props }) => (
    <CSSTransition
        {...props}
        timeout={10}
        classNames="slide"
    >
        {children}
    </CSSTransition>
)

export class Home extends Component {
  static displayName = Home.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);


    window.onload = this.tuneRowsAndColumns;
    window.onresize = this.tuneRowsAndColumns;

    this.row = 1;
    this.column = 1;

    this.array = new Array(this.row);
    for (var i = 0; i < this.column; i++) {
        this.array[i] = new Array(this.column);
    }

    for (let i = 0; i < this.row*this.column; i++) {

        this.array[Math.floor(i / this.column)][i % this.column] = ' ';
    }
    
    this.state = {
        name: 'React',
        items: this.array, 
        projects1: [], 
        loading: true
    };



      
  }


    componentDidMount() {
        this.populateWeatherData();
    }

  toggleNavbar () {
      this.setState({
          collapsed: !this.state.collapsed
      });
    }

    tuneColumns = () =>  {
        let contentWidth = document.getElementById('mainContent').clientWidth;
        var possibleColumns = Math.floor(contentWidth / 180);
        this.column = possibleColumns;

        const newArray = new Array(this.row);
        for (var i = 0; i < this.row; i++) {
            newArray[i] = new Array(possibleColumns);
        }

        this.populateWeatherData(this.row * possibleColumns);
        for (let i = 0; i < this.row * possibleColumns; i++) {

            newArray[Math.floor(i / possibleColumns)][i % possibleColumns] = this.state.projects1[i].name;
        }

        
        this.setState(prevState => ({
            ...prevState,
            items: newArray
        }))

    }

    tuneRows = () => {

        let contentHeight = document.getElementById('mainContent').clientHeight;
        var possibleRows = Math.floor(contentHeight / 130);

        const newArray = new Array(possibleRows);
        for (var i = 0; i < possibleRows; i++) {
            newArray[i] = new Array(this.column);
        }

        this.populateWeatherData(possibleRows * this.column);

        for (let i = 0; i < possibleRows * this.column; i++) {

            newArray[Math.floor(i / this.column)][i % this.column] = this.state.projects1[i].name;
        }

        this.row = possibleRows;
        this.setState(prevState => ({
            ...prevState,
            items: newArray
        }))
    }

    tuneRowsAndColumns = () => {
        this.tuneColumns();
        this.tuneRows();
        
    }

    

    
    render() {
        return (
            <>
                
                <div className={styles.header}>
                    <h3 className={styles.header}>Header</h3>
                    
                </div>


                <div>
                    <NavLink tag={ Link} className={styles.leftSide} to="/items">go</NavLink>
                    {/*<h2 className={styles.leftSide}>Left side</h2>*/}
                    
                </div>

                <div className={styles.mainContent} id="mainContent">

                    <div slassName={styles.table}>
                        <Table>
                            <Body>
                                <TransitionGroup> 
                                    {this.state.items.map(item => (
                                        <Slide key={item[1]}>
                                            <Row>
                                                {item.map(prop => (
                                                    <Cell>
                                                        <button className={styles.button}>
                                                            {prop}
                                                        </button>
                                                    </Cell>
                                                ))}
                                            </Row>
                                        </Slide>
                                    ))}
                                </TransitionGroup>
                            </Body>
                        </Table>
                        
                    </div>
                    

                    
                </div>

                

                <div>
                    <h2 className={styles.rightSide}>Right side</h2>
                </div>

                <div className={styles.footerDiv}>
                    <h2 className={styles.footer}>Footer</h2>
                </div>


            </>
            
                
      );
    }


    async populateWeatherData(count) {
        const response = await fetch(`project?firstId=1&count=${count}`);
        const data = await response.json();
        this.setState({ projects1: data, loading: false });
    }
}
