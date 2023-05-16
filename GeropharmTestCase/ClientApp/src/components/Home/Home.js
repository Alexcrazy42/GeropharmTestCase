// нужный
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

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);


        

        this.row = 0;
        this.column = 0;

        this.array = new Array(this.row);
        for (var i = 0; i < this.column; i++) {
            this.array[i] = new Array(this.column);
        }

        for (let i = 0; i < this.row * this.column; i++) {

            this.array[Math.floor(i / this.column)][i % this.column] = ' ';
        }

        window.onload = this.tuneRowsAndColumns;
        window.onresize = this.tuneRowsAndColumns;
        //window.addEventListener('load', () => {
        //    this.tuneRowsAndColumns();
        //});
        window.addEventListener('resize', () => {
            this.tuneRowsAndColumns();
        });
        window.addEventListener('pageshow', () => {
            this.tuneRowsAndColumns();
        });

        this.state = {
            name: 'React',
            items: this.array,
            projects: []
        };




    }


    componentDidMount() {
        this.getProjectsFromDb(this.row * this.column, 1);

    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    tuneRowsAndColumns = () => {
        if(document.getElementById('mainContent').clientWidth != null && document.getElementById('mainContent').clientHeight != null) {
            let contentWidth = document.getElementById('mainContent').clientWidth;
            let contentHeight = document.getElementById('mainContent').clientHeight;
            var possibleColumns = Math.floor((contentWidth - 60) / 180);
            var possibleRows = Math.floor((contentHeight - 60) / 130);

            var possibleSize = possibleColumns * possibleRows;
            var currentSize = this.row * this.column;

            this.row = possibleRows;
            this.column = possibleColumns;
            const newArray = new Array(possibleRows);
            if (possibleSize > currentSize) {
                this.getProjectsFromDb(possibleSize, 1);
            }

            for (var i = 0; i < possibleRows; i++) {
                newArray[i] = new Array(possibleColumns);
            }
            for (let i = 0; i < possibleRows * possibleColumns; i++) {

                if (this.state.projects[i].name != null) {
                    newArray[Math.floor(i / possibleColumns)][i % possibleColumns] = this.state.projects[i].name;
                }
                else {
                    newArray[Math.floor(i / possibleColumns)][i % possibleColumns] = ' ';
                }
                
            }


            const elementsColumns = document.querySelectorAll('.TableCell');
            for (let i = 0; i < elementsColumns.length; i++) {
                var marginPx = Math.floor((contentWidth - possibleColumns * 150) / (possibleColumns + 1));
                elementsColumns[i].style.marginLeft = `${marginPx}px`;
            }

            const elementsRows = document.querySelectorAll('.TableRow');
            for (let i = 0; i < elementsRows.length; i++) {
                var marginTopPx = Math.floor((contentHeight - possibleRows * 100) / (possibleRows + 1));
                elementsRows[i].style.marginTop = `${marginTopPx}px`;
            }

            this.setState(prevState => ({
                ...prevState,
                items: newArray
            }))
        }
        
    }





    render() {
        return (
            <>
                <body>
                    <div className={styles.header}>
                        <h3 className={styles.header}>Header</h3>

                    </div>


                    <div>
                        <h3 className={styles.leftSide}>Left side</h3>
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
                                                        <Cell id="cell">
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
                        <button onClick={() => this.tuneRowsAndColumns()} className={styles.rightSide}>button</button>
                    </div>

                    <div className={styles.footerDiv}>
                        <h2 className={styles.footer}>Footer</h2>
                    </div>
                </body>
                <script>
                    
                </script>
            </>

            
        );
    }


    async getProjectsFromDb(count = 1, firstId = 1) {
        
        const response = await fetch(`project?firstId=${firstId}&count=${count}`); // partial load request - `project?firstId=${firstId}&count=${count}` 
        const data = await response.json();
        this.setState({ projects: data });

        // logic to partial load requests
        //if (firstId == 1) {
        //    this.setState({ projects: data });
        //    //console.log(this.state.projects)
        //}
        //else {
        //    //for (var i in data) {
        //    //    this.state.projects.push(i);
        //    //}
        //    this.state.projects.push(data);
        //    //console.log(this.state.projects)
        //}

    }
}
