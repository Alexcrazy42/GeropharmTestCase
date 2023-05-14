import React, { useState, useEffect } from 'react'; 

const ProjectsItems = () => {
    const [projects, setProjects] = useState([]); 
    const count = 10;
    const firstId = 1; 

    useEffect(() => {
        fetch(`project/all`)
            .then((results) => {
                return results.json();
            })
            .then(data => {
                setProjects(data);
            })
    }, []);

    return (
        <main>
            <h1>Список проектов:</h1>
            {
                (projects != null) ? 
                    projects.map((project) => {
                        <h3>{project.name}</h3>
                    })
                    : <div>Loading...</div>
            }
        </main>    
    )
}

export default ProjectsItems;