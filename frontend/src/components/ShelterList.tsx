import React from "react";
import { AppState } from "../reducers/rootReducer";
import { ShelterCardPreview } from "./ShelterCardPreview";
import { connect } from "react-redux";

const ShelterList: React.FC<Props> = (shelters: Props) => {
    return (
        <div className="container">
            <div className="row">
                <input type="search" name="" id="search" />
            </div>
            <div className="row">
                {
                    shelters.shelters.map(x => {
                        return (
                            <ShelterCardPreview card={x} key={x.id}></ShelterCardPreview>
                        )
                    })
                }
            </div>
        </div>
    )
}

const mapStateToProps = (state: AppState) => {
    return {
        shelters: state.shelters.shelters
    }
}
type Props  = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps, null)(ShelterList);