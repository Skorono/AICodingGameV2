import {JSX, Component, ReactElement, useEffect, useState} from "react";
import "./styles/UnfoldingElement.css"
export default function ({ id, header, children }: { id: string, header: string, children: ReactElement }){
    const [isOpen, SetOpen] = useState(true);
    
    return(
        <div id={id} className="container">
            <div className="panel">
                <h1>{header}</h1>
                <button className={"openBtn"} onClick={() => {SetOpen(!isOpen)}}></button>
            </div>
            <div className="collapsed" hidden={isOpen}>
                {children}
            </div>
        </div>
    )
}
