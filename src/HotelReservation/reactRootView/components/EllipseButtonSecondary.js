import React from "react";
import { StyleSheet, TouchableOpacity, Text } from "react-native";
import colors from "../config/colors";
import defaultStyles from "../config/defaultStyles";

export const EllipseButtonSecondary = ({ onClick, name, marginTop }) => {
    return (
        <TouchableOpacity
            onPress={onClick}
            style={{ ...styles.container, marginTop: marginTop }}
        >
            <Text style={defaultStyles.text20Black}>{name}</Text>
        </TouchableOpacity>
    );
};

const styles = StyleSheet.create({
    container: {
        width: "60%",
        height: 45,
        backgroundColor: colors.secondary,
        zIndex: 1,
        justifyContent: "center",
        alignSelf: "center",
        alignItems: "center",
        borderRadius: 21,
        shadowColor: colors.black,
        shadowRadius: 10,
        elevation: 8,
    },
    text: {
        position: "relative",
        marginVertical: "15%",
        paddingHorizontal: "5%",
        textAlign: "center",
        fontFamily: "Italiana-Regular",
        fontSize: 36,
        color: colors.white,
    },
});
